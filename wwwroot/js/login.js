function validateForm() {
    var email = document.getElementById("Email").value;
    var password = document.getElementById("Password").value;

    if (!email.includes("@") || !email.endsWith(".com")) {
        alert("Invalid email format. Email must include '@' and end with '.com'");
        return false;
    }

    if (password.length < 6) {
        alert("Password must be at least 6 characters");
        return false;
    }

    return true;
}
