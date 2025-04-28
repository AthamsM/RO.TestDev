document.getElementById("registerForm").addEventListener("submit", async function (event) {
    event.preventDefault();
    
    const userName = document.getElementById("userName").value.trim();
    const name = document.getElementById("name").value.trim();
    const email = document.getElementById("email").value.trim();
    const password = document.getElementById("password").value.trim();
    const passwordConfirmation = document.getElementById("passwordConfirmation").value.trim();
    
    const role = 1;

    const message = document.getElementById("message");

    if (!userName || !name || !email || !password || !passwordConfirmation) {
        message.textContent = "Por favor, preencha todos os campos.";
        message.style.color = "red";
        return;
    }

    if (password !== passwordConfirmation) {
        message.textContent = "As senhas não coincidem.";
        message.style.color = "red";
        return;
    }

    try {
        const response = await fetch("http://localhost:5087/api/user", {
            method: "POST",
            headers: {"Content-Type": "application/json"},
            body: JSON.stringify({ userName, name, email, password, passwordConfirmation, role })
        });

        if (response.ok) {
            message.textContent = "Cadastro feito com sucesso!";
            message.style.color = "green";
            window.location.href = "index.html";
        } else {
            const error = await response.text();
            message.textContent = `Erro: ${error}`;
            message.style.color = "red";
        }
    } catch (error) {
        message.textContent = "Erro ao conectar ao servidor.";
        message.style.color = "red";
        console.error(error);
    }
});
