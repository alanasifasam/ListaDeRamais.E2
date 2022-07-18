const btnMenu = document.querySelector('#btnMenu');
const sidebar = document.querySelector('.sidebar');
const home = document.querySelector('.homeContent');
const Cards = document.querySelector('.Cards');
const main = document.querySelector('.main');
const toolipe = document.querySelector('.toolipe');
//EVENTOS DE click 
btnMenu.addEventListener('click', () => {
    sidebar.classList.toggle('active');
    home.classList.toggle('active');
    Cards.classList.toggle('active');
    main.classList.toggle('active');
    toolipe.classList.toggle('active');
  
});





function alertaExcluir(){
    alert('Caso o ramal esteja vinculado com algum funcionário, o vínculo será excluído junto com o ramal.')
};

function alertaExcluirFuncionario() {
    alert('Caso o funcionário esteja vinculado com algum ramal, o vínculo será excluído junto com o funcionário.')
};


$(document).ready(function () {
    $('#ModalError').modal('show');
});
