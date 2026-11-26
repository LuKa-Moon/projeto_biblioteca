const url = "http://localhost:5086";

const GRR_USER = document.body.dataset.grr;

async function BuscarLivros() {
  const resposta = await fetch(url + "/livros");

  if (!resposta.ok) {
    alert("Erro ao buscar livros.");
    return;
  }

  const livros = await resposta.json();
  console.log(livros);

  const livrosLista = document.getElementById("livros-lista");
  livrosLista.innerHTML = "";

  livros.forEach((livro) => {
    const li = document.createElement("li");
    li.classList.add("card");

    const capa = document.createElement("img");
    capa.src = livro.capaUrl || "";
    capa.alt = `Capa de ${livro.nome}`;

    const nome = document.createElement("h3");
    nome.textContent = livro.nome;

    const botao = document.createElement("button");
    botao.textContent = "Reservar";

    botao.addEventListener("click", () => {
      ReservarLivro(livro);
    });

    li.appendChild(capa);
    li.appendChild(nome);
    li.appendChild(botao);

    livrosLista.appendChild(li);
  });
}

async function ReservarLivro(livro) {
  try {
    const parametros = new URLSearchParams({
      grr: GRR_USER,
      idLivro: livro.id.toString(),
    });

    const resposta = await fetch(`${url}/reservas?${parametros}`, {
      method: "POST",
    });

    if (resposta.ok) {
      alert(`Reserva do livro "${livro.nome}" realizada com sucesso!`);
    } else {
      const mensagem = await resposta.text();
      alert(`Não foi possível realizar a reserva:\n${mensagem}`);
    }
  } catch (erro) {
    console.error(erro);
    alert("Erro de comunicação com o servidor.");
  }
}

window.onload = BuscarLivros;
