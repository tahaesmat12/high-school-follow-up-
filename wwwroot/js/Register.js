function validateForm() {
    var email = document.getElementById("Email").value;
    var parentName = document.getElementById("ParentName").value;
    var confirmPassword = document.getElementById("ConfirmPassword").value;

    if (!email.includes("@") || !email.endsWith(".com")) {
        alert("Invalid email format. Email must include '@' and end with '.com'");
        return false;
    }

    if (confirmPassword !== document.getElementById("Password").value) {
        alert("Passwords do not match");
        return false;
    }

    if (!/^[a-zA-Z]+$/.test(parentName)) {
        alert("Parent name must contain only letters");
        return false;
    }

    return true;
}
