document.getElementById("checkoutForm").addEventListener("submit", function (e) {
    e.preventDefault();

    const name = document.getElementById("name").value.trim();
    const email = document.getElementById("email").value.trim();
    const address = document.getElementById("address").value.trim();

    const nameError = document.getElementById("nameError");
    const emailError = document.getElementById("emailError");
    const addressError = document.getElementById("addressError");
    const message = document.getElementById("message");


    nameError.textContent = "";
    emailError.textContent = "";
    addressError.textContent = "";
    message.textContent = "";

    let hasError = false;

    if (!name) {
        nameError.textContent = "Full name is required";
        hasError = true;
    }

    if (!email) {
        emailError.textContent = "Email is required";
        hasError = true;
    } else {
        const emailPattern = /^[^@\s]+@[^@\s]+\.[^@\s]+$/;
        if (!emailPattern.test(email)) {
            emailError.textContent = "Invalid email format";
            hasError = true;
        }
    }

    if (!address) {
        addressError.textContent = "Address is required";
        hasError = true;
    }

    if (hasError) return;

    // Show submitting...
    message.style.color = "black";
    message.textContent = "Submitting...";




    // API call 
    fetch("https://localhost:7045/api/Checkout", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            fullName: name,
            email: email,
            address: address,
            paymentMethod: document.querySelector('input[name="payment"]:checked').value
        })
    })
        .then(res => res.json())
        .then(data => {
            if (data.success) {
                message.style.color = "green";
                message.textContent = data.message;
                document.getElementById("checkoutForm").reset();
            } else {
                message.style.color = "red";
                message.textContent = data.message;
            }
        })
        .catch(() => {
            message.style.color = "red";
            message.textContent = "Server error!";
        });
});
