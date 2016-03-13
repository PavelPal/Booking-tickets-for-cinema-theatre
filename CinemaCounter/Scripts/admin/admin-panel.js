function activateModal() {
    var modalEl = document.createElement("div");
    modalEl.style.width = "400px";
    modalEl.style.height = "300px";
    modalEl.style.margin = "100px auto";
    modalEl.style.backgroundColor = "#fff";

    mui.overlay("on", modalEl);
}

function addTask(goal, inputValue, appendObject) {
    if (inputValue !== "") {
        $.ajax({
            url: "/Admin/AddToTask",
            method: "POST",
            data: {
                'body': inputValue,
                'goal': goal
            },
            dataType: "json",
            beforeSend: function() {
                $("#fountainG").css({
                    '-ms-opacity': "1",
                    'opacity': "1"
                });
            },
            complete: function() {
                $("#fountainG").css({
                    '-ms-opacity': "0",
                    'opacity': "0"
                });
            }
        }).done(function(data) {
            if (appendObject.children(".todo-list-info").length > 0) {
                appendObject.children(".todo-list-info").remove();
            }
            $("<li class=\"todo-list-item\" id=\"todo-list-item-" + data.Id + "\"><div class=\"checkbox\">" +
                "\n<input type=\"checkbox\" id=\"checkbox-" + data.Id + "\"/>" +
                "\n<label for=\"checkbox-" + data.Id + "\">" + data.Body + "</label></div>" +
                "<div class=\"pull-right action-buttons\">" +
                "\n<a class=\"edit\">\n<i class=\"fa fa-pencil\"></i></a>" +
                "\n<a class=\"flag\">\n<i class=\"fa fa-flag\"></i></a>" +
                "\n<a class=\"trash\">\n<i class=\"fa fa-trash\"></i></a></div></li>").show("slow").appendTo(appendObject);
        });
    }
}

function deleteTask(removeFromObject, taskId) {
    var id = taskId.substring(15);
    $.ajax({
        url: "/Admin/DeleteTask",
        method: "POST",
        data: {
            'id': id
        },
        dataType: "json",
        beforeSend: function() {
            $("#fountainG").css({
                '-ms-opacity': "1",
                'opacity': "1"
            });
        },
        complete: function() {
            $("#fountainG").css({
                '-ms-opacity': "0",
                'opacity': "0"
            });
            removeFromObject.children("#" + taskId).remove();
            if (removeFromObject.children().length === 0) {
                $("<p class=\"todo-list-info\">" +
                    "<i class=\"fa fa-info-circle color-blue\"></i> " +
                    "Нет заданий для удаления</p>").show("slow").appendTo(removeFromObject);
            }
        }
    });
}

function togglePriority(changedObject, taskId) {
    var id = taskId.substring(15);
    $.ajax({
        url: "/Admin/TogglePriority",
        method: "POST",
        data: {
            'id': id
        },
        dataType: "json",
        beforeSend: function() {
            $("#fountainG").css({
                '-ms-opacity': "1",
                'opacity': "1"
            });
        },
        complete: function() {
            $("#fountainG").css({
                '-ms-opacity': "0",
                'opacity': "0"
            });
            changedObject.toggleClass("color-red");
        }
    });
}

function toggleState(changedObject, taskId) {
    var id = taskId.substring(15);
    $.ajax({
        url: "/Admin/ToggleState",
        method: "POST",
        data: {
            'id': id
        },
        dataType: "json",
        beforeSend: function() {
            $("#fountainG").css({
                '-ms-opacity': "1",
                'opacity': "1"
            });
        },
        complete: function() {
            $("#fountainG").css({
                '-ms-opacity': "0",
                'opacity': "0"
            });
        }
    });
}

$(document).ready(function() {
    $(".add-form").on("click", "#add-to-remove", function() {
        var goal = "remove",
            inputValue = $("#add-to-remove-input").val(),
            appendObject = $("#remove-task");
        addTask(goal, inputValue, appendObject);
        $("#add-to-remove-input").val("");
    });
    $(".add-form").on("click", "#add-to-edit", function() {
        var goal = "edit",
            inputValue = $("#add-to-edit-input").val(),
            appendObject = $("#edit-task");
        addTask(goal, inputValue, appendObject);
        $("#add-to-edit-input").val("");
    });
    $(".add-form").on("click", "#add-to-add", function() {
        var goal = "add",
            inputValue = $("#add-to-add-input").val(),
            appendObject = $("#add-task");
        addTask(goal, inputValue, appendObject);
        $("#add-to-add-input").val("");
    });

    $("html").delegate(".trash", "click", function() {
        var taskId = $(this).parent().parent().attr("id");
        var removeFromObject = $(this).parent().parent().parent();
        deleteTask(removeFromObject, taskId);
    });

    $("html").delegate(".flag", "click", function() {
        var taskId = $(this).parent().parent().attr("id");
        var changedObject = $(this).children();
        togglePriority(changedObject, taskId);
    });

    $("html").delegate(".checkbox", "click", function() {
        var taskId = $(this).parent().attr("id");
        var changedObject = $(this).children();
        toggleState(changedObject, taskId);
    });
});