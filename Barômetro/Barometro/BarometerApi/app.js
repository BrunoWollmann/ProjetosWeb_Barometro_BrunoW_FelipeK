fetch('http://localhost:5000/barometer')
    .then(response => response.json())
    .then(data => {
        // por o code pra exibir os dados na tela
        console.log(data);
    })
    .catch(error => {
        console.error('Erro:', error);
    });
