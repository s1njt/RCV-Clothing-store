function updateDateTime() {
    var currentDateTime = new Date();
    var month = currentDateTime.toLocaleString('default', { month: 'long' }).toUpperCase();
    var date = currentDateTime.getDate();
    var year = currentDateTime.getFullYear();
    var formattedDate = ("0" + date).slice(-2) + "." + ("0" + (currentDateTime.getMonth() + 1)).slice(-2) + "." + year;
    var timeString = currentDateTime.toLocaleTimeString();
    document.getElementById("current-time").innerHTML = month + " " + formattedDate + " ";
}

setInterval(updateDateTime, 0);
