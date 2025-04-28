document.getElementById("loginForm").addEventListener("submit", async function (event) {
    event.preventDefault();
  
    const email = document.getElementById("email").value;
    const password = document.getElementById("password").value;
  
    const response = await fetch("http://localhost:5087/api/auth/login", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({ email, password })
    });
  
    const message = document.getElementById("message");
  
    if (response.ok) {
        const data = await response.json();
        localStorage.setItem("accessToken", data.accessToken);
        message.textContent = "Login feito com sucesso!";
        message.style.color = "green";
        const token = localStorage.getItem("accessToken");
        const payloadBase64 = token.split(".")[1];
        const decodedPayload = JSON.parse(atob(payloadBase64));

        const userRole = decodedPayload["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"]
        
        if(userRole == "Admin"){
            window.location.href = "produtosAdmin.html";
        }else{
            window.location.href = "produtos.html";
        }

    } else {
      const error = await response.text();
      message.textContent = `Erro: ${error}`;
      message.style.color = "red";
    }
  });
  