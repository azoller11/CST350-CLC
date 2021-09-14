$(function () {
    console.log("Page is ready");


   /* $(document).on("click", ".game-button", function (event) {
        event.preventDefault();

        var buttonNumber = $(this).val();
        console.log("Button number " + buttonNumber + " was clicked");
        doButtonUpdate(buttonNumber);
    });*/

    $(document).bind("contextmenu", function (e) {
        e.preventDefault();
        console.log("Right click. Prevent context menu from showing.");

    });

    $(document).on("mousedown", ".game-button", function (event) {
        switch (event.which) {
            case 1:
                event.preventDefault();
                var buttonNumber = $(this).val();
                doButtonUpdate(buttonNumber, "/button/ShowOneButton");
                console.log("Button number" + buttonNumber + "was a left click");
                break;
            case 2:
                
                break;
            case 3:
                event.preventDefault();
                var buttonNumber = $(this).val();
                doButtonUpdate(buttonNumber, "/button/RightClickShowOneButton");
                console.log("Button number" + buttonNumber + "was a right click");
                break;
            default:
                alert('Nothing');


        }



    });



});

function doButtonUpdate(buttonNumber, urlString) {
    $.ajax({
        dataType: "json",
        method: "POST",
        url: urlString,
        data: {
            "buttonNumber": buttonNumber
        },
        success: function (data) {
            console.log(data);
            $("#" + buttonNumber).html(data);
        }
    });

}