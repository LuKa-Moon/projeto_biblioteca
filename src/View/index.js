const url = "http://localhost:5086/livros";

async function BuscarLivros() {
    const resposta = await fetch(url);
    const livros = await resposta.json();
    console.log(livros);

    const livrosLista = document.getElementById("livros-lista");
    livrosLista.innerHTML = '';

    livros.forEach(livro => {
        const li = document.createElement('li');
    });
}

window.onload = BuscarLivros();