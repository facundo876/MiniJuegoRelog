$(document).ready(function () {
    jQueryModalGet = (url, title) => {
        try {
            $.ajax({
                type: 'GET',
                url: url,
                contentType: false,
                processData: false,
                success: function (res) {
                    $('#form-modal .modal-body').html(res.html);
                    $('#form-modal .modal-title').html(title);
                    $('#form-modal').modal('show');
                },
                error: function (err) {
                    console.log(err)
                }
            })
            //to prevent default form submit event
            return false;
        } catch (ex) {
            console.log(ex)
        }

    }
})

var time = 0;
var running = 0;

function startPause() {
    if (running == 0) {
        running = 1;
        increment();
        document.getElementById("startPause").innerHTML = "PAUSE";
    } else {
        running = 0;
        document.getElementById("startPause").innerHTML = "RESUME";
    }
}

function reset() {
    running = 0;
    time = 0;
    document.getElementById("startPause").innerHTML = "START";
    document.getElementById("output").innerHTML = "00:00:00";
}

function increment() {
    if (running == 1) {
        setTimeout(function () {
            time++;
            var mins = Math.floor(time / 10 / 60);
            var secs = Math.floor(time / 10 % 60);
            var tenths = time % 10;
            if (mins < 10) {
                mins = "0" + mins;
            }
            if (secs < 10) {
                secs = "0" + secs;
            }
            document.getElementById("output").innerHTML = mins + ":" + secs + ":" + "0" + tenths;
            document.getElementById("output2").value = mins + ":" + secs + ":" + "0" + tenths;
            increment();
        }, 100);
    }
}
