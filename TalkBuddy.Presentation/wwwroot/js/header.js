﻿document.getElementById('user-avatar').addEventListener('click', (event) => {
    const logoutContainer = document.getElementById('logout-container');
    logoutContainer.style.display === 'block'
        ? logoutContainer.style.display = 'none'
        : logoutContainer.style.display = 'block';
});

document.getElementById('btn-logout').addEventListener('click', () => {
    document.location.href = 'http://localhost:3000/ChatPage?handler=LogOut';
});
