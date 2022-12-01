$(function () {
    console.log("Page is ready");

    /*
    $(".TaskRadio").click(function (event) {
        event.preventDefault();

        var taskId = $(this).val();
        console.log("task " + taskId + "was clicked");
    }) */


    
    $(".TaskRadio").change(function () {
        console.log("Radio button changed")
        var taskId = $(this).val();
        console.log("task " + taskId + " was clicked");
        doTaskUpdate(taskId);
    })

    function doTaskUpdate(taskId) {
        $.ajax({
            type: "POST",
            url: 'Day/MarkAsDone',
            data: $("form").serialize(),
            success: function (data) {
                console.log(data);
                $("#"+ taskId).html(data)
            }
        })
    }

    $(".SubmitButton").click(function () {
        event.preventDefault();
        console.log("submit button clicked");
        doTaskUpdate();

       


    });

    
    /*
    function doTaskUpdate() {
        $.ajax({
            type: "POST",
            url: 'Day/DetailsTask',
            data: $('form').serialize(),
            success: function (data) {
                console.log(data);
                //$(".taskPageDiv").html(data);
            }
        })
    }
    /*
    $.ajax({
        datatype:"json"
        type: "POST",
        url: "Task/DetailsTask",
        data: {
            ""
        }

    }) */

    
})

