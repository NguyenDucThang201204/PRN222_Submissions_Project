const connection = new signalR.HubConnectionBuilder().withUrl("/hub").build();
connection.on("Reload", function (id) {
    location.reload();
});
connection.start()
    .then(() => console.log("SignalR connected"))
    .catch(err => console.error(err));
    //
