
using Microsoft.EntityFrameworkCore;
using TalkBuddy.Common.Enums;
using TalkBuddy.DAL.Interfaces;
using TalkBuddy.Domain.Entities;
using TalkBuddy.Service.Interfaces;

namespace TalkBuddy.Service.Implementations;

public class FriendShipService : IFriendShipService
{
    private readonly IFriendShipRepository _friendShipRepository;
    private readonly IUnitOfWork _unitOfWork;
	private readonly IClientRepository _clientRepository;

    public FriendShipService(IFriendShipRepository friendShipRepository, IUnitOfWork unitOfWork, IClientRepository clientRepository)
    {
        _friendShipRepository = friendShipRepository;
		_clientRepository = clientRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task CreateFriendShip(Friendship friendShip)
    {
        var friendShipStatus = await GetFriendShipStatusAsync(friendShip.SenderID, friendShip.ReceiverId);
        if (friendShipStatus == null)
        {
            await _friendShipRepository.AddAsync(friendShip);
            await _unitOfWork.CommitAsync();
        }
        else if (friendShipStatus.Equals(FriendShipRequestStatus.REJECTED) || friendShipStatus.Equals(FriendShipRequestStatus.CANCEL))
        {
            var x = await _friendShipRepository.GetAsync(x =>
                (x.SenderID == friendShip.SenderID && x.ReceiverId == friendShip.ReceiverId)||
                (x.SenderID == friendShip.ReceiverId && x.ReceiverId == friendShip.SenderID));
            x.Status = FriendShipRequestStatus.WAITING;
            x.SenderID = friendShip.SenderID;
            x.ReceiverId = friendShip.ReceiverId;
            await _friendShipRepository.UpdateAsync(x);
            await _unitOfWork.CommitAsync();
        }
    }
    
    public FriendShipRequestStatus? GetFriendShipStatus(Guid senderId, Guid receiverId)
    {
        var x =  _friendShipRepository.Get(x =>
            (x.SenderID == senderId && x.ReceiverId == receiverId)||
            (x.SenderID == receiverId && x.ReceiverId == senderId));
        return x?.Status;
    }

    public async Task<FriendShipRequestStatus?> GetFriendShipStatusAsync(Guid senderId, Guid receiverId)
    {
        var x = await _friendShipRepository.GetAsync(x =>
            (x.SenderID == senderId && x.ReceiverId == receiverId)||
            (x.SenderID == receiverId && x.ReceiverId == senderId));
        return x?.Status;
    }

    public async Task<IQueryable<Friendship>> GetFriendInvitation(Guid receiverId)
    {
        var listFriend = (await _friendShipRepository.FindAsync(x => x.ReceiverId == receiverId))
            .Include(fs => fs.Sender);
        var listInvitation = listFriend.Where(friendship => friendship.Status == FriendShipRequestStatus.WAITING);
        return listInvitation;
    }

    
    public async Task AcceptFriendInvitation(Guid friendShipId)
    {
        var friendship = await _friendShipRepository.GetAsync(x => x.Id == friendShipId) ?? throw new Exception("Not Found FriendInvitation");
		if (friendship.Status != FriendShipRequestStatus.WAITING) return;

		friendship.Status = FriendShipRequestStatus.ACCEPTED;
		await _friendShipRepository.UpdateAsync(friendship);
        await _unitOfWork.CommitAsync();
    }
    public async Task RejectFriendInvitation(Guid friendShipId)
    {
        var friendship = await _friendShipRepository.GetAsync(x => x.Id == friendShipId) ?? throw new Exception("Not Found FriendInvitation");
        friendship.Status = FriendShipRequestStatus.REJECTED;
        await _friendShipRepository.UpdateAsync(friendship);
        await _unitOfWork.CommitAsync();
    }

    public async Task CancelInvitation(Guid senderId, Guid receiverId)
    {
        var friendship =
        await _friendShipRepository.GetAsync(x => x.SenderID == senderId && x.ReceiverId == receiverId);
        friendship.Status = FriendShipRequestStatus.CANCEL;
        await _friendShipRepository.UpdateAsync(friendship);
        await _unitOfWork.CommitAsync();
    }

    public async Task<IEnumerable<Client>> GetClientFriends(Guid clientId)
    {
        var friendships = await (await _friendShipRepository.GetAllAsync())
            .Where(fs => fs.Status == FriendShipRequestStatus.ACCEPTED)
            .Include(fs => fs.Sender)
            .Include(fs => fs.Receiver)
            .ToListAsync();

        return friendships.Select(fs =>
        {
            if (fs.SenderID == clientId)
                return fs.Receiver;

            return fs.Sender;
        });
    }

    public async Task DeleteFriendShip(Guid friendId, Guid clientId)
    {
        var x = await _friendShipRepository.GetAsync(x =>
               (x.SenderID == friendId && x.ReceiverId == clientId) ||
               (x.SenderID == clientId && x.ReceiverId == friendId));

        x.Status = FriendShipRequestStatus.REJECTED;
        await _friendShipRepository.UpdateAsync(x);
        await _unitOfWork.CommitAsync();
    }

    public async Task CreateFriendship(Guid clientId, Guid friendId)
    {
		var sender = await _clientRepository.GetAsync(c => c.Id == clientId) ?? throw new Exception("Client not found");
		var receiver = await _clientRepository.GetAsync(c => c.Id == friendId) ?? throw new Exception("Receiver not found");
        var friendship = await _friendShipRepository.GetAsync(x =>
               (x.SenderID == friendId && x.ReceiverId == clientId) ||
               (x.SenderID == clientId && x.ReceiverId == friendId));

		if (friendship == null)
		{
			friendship = new Friendship
			{
				SenderID = clientId,
				ReceiverId = friendId,
				Status = FriendShipRequestStatus.WAITING,
				RequestDate = DateTime.Now
			};

			await _friendShipRepository.AddAsync(friendship);
		}
		else 
		{
			friendship.Status = FriendShipRequestStatus.WAITING;
			friendship.RequestDate = DateTime.Now;
			friendship.SenderID = clientId;
			friendship.ReceiverId = friendId;

			await _friendShipRepository.UpdateAsync(friendship);
		}

		await _unitOfWork.CommitAsync();
    }
}
