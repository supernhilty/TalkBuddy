﻿using TalkBuddy.Common.Enums;
using TalkBuddy.Domain.Entities;

namespace TalkBuddy.Service.Interfaces;

public interface IReportService
{
    Task CreateReport(Report report);

    Task DismissReport(Guid reportId);
    Task BanUser(Guid reportId, SuspensionType suspensionType);

    Task<IQueryable> GetSuspendedClient();
}