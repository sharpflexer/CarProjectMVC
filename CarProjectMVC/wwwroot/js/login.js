if ("serviceWorker" in navigator) {
    navigator.serviceWorker.register("/authenticationhandler.js");
}
const channelTokenBroadcast = new BroadcastChannel('channelToken');
const channelRefreshBroadcast = new BroadcastChannel('channelRefresh');

var tokenKey = "accessToken";

document.getElementById("submitLogin").addEventListener("click", async e => {
    e.preventDefault();

    const formData = new FormData();
    formData.append("username", document.getElementById("username").value);
    formData.append("password", document.getElementById("password").value);

    const response = await fetch("/Auth/Token", {
        method: "POST",
        headers: { "Accept": "application/json" },
        body: formData
    });
    const data = await response.json();

    if (response.ok === true) {
        /*        localStorage.setItem('AccessToken', JSON.stringify('Bearer ' + data.accessToken));*/
        var accessToken = "Bearer " + data.accessToken;
        channelTokenBroadcast.postMessage({ accessToken: accessToken });
        channelRefreshBroadcast.postMessage({ refreshToken: data.refreshToken });
        createCookie('Refresh', data.refreshToken, 1);
        window.location.href = "/Read/Index";

    }

    function createCookie(name, value, days) {
        var expires;
        if (days) {
            var date = new Date();
            date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
            expires = "; expires=" + date.toGMTString() + "; ";
        }
        else {
            expires = "";
        }
        var cookieString = encodeURIComponent(name) + "=" + encodeURIComponent(value) + encodeURIComponent(expires) + "path=/";
        document.cookie = cookieString;
    }
});