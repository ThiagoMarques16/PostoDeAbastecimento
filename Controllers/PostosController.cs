using ListaDePostos.Context;
using ListaDePostos.Models;
using Microsoft.AspNetCore.Mvc;

namespace ListaDePostos.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PostosController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public PostosController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PostoDeAbastecimento>> BuscarPostos()
        {
            var postos = _appDbContext.PostosDeAbastecimento.ToList();
            return Ok(postos);
        }

        [HttpGet("por-id/{id:int}")]
        public ActionResult<PostoDeAbastecimento> BuscarPostoPorId(int id)
        {
            var posto = _appDbContext.PostosDeAbastecimento.FirstOrDefault(x => x.Id == id);

            if(posto is null)
            {
                return NotFound();
            }

            return Ok(posto);
        }

        [HttpGet("por-nome/{nome}")]
        public ActionResult<IEnumerable<PostoDeAbastecimento>> BuscarPostoPorNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
            {
                return BadRequest("O nome não pode ser nulo ou vazio.");
            }

            var postos = _appDbContext.PostosDeAbastecimento.Where(x => x.Nome.Contains(nome)).ToList();

            return Ok(postos);
        }

        [HttpGet("por-cnpj/{cnpj}")]
        public ActionResult<IEnumerable<PostoDeAbastecimento>> BuscarPostoPorCnpj(string cnpj)
        {
            if (string.IsNullOrEmpty(cnpj))
            {
                return BadRequest("O CNPJ não pode ser nulo ou vazio.");
            }

            var postos = _appDbContext.PostosDeAbastecimento.Where(x => x.Cnpj.Contains(cnpj)).ToList();

            return Ok(postos);
        }

        [HttpGet("com-caracteristicas")]
        public ActionResult<IEnumerable<PostoDeAbastecimento>> BuscarPorCaracteristicas(bool? banheiro, bool? calibrador, bool? lavaJato)
        {
            var sentences = _appDbContext.PostosDeAbastecimento.AsQueryable();

            if(banheiro.HasValue){
                sentences = sentences.Where(x => x.Banheiro == banheiro.Value);
            }

            if(calibrador.HasValue){
                sentences = sentences.Where(x => x.Calibrador == calibrador.Value);
            }

            if(lavaJato.HasValue){
                sentences = sentences.Where(x => x.LavaJato == lavaJato.Value);
            }

            var postos = sentences.ToList();
            return Ok(postos);
        }

        [HttpGet("Gasolina-menor-que/{precoGasolina}")]
        public ActionResult<IEnumerable<PostoDeAbastecimento>> BuscarGasolinaMenorQue(decimal precoGasolina)
        {
            if (precoGasolina <= 0)
            {
                return BadRequest("O valor nao pode ser 0.");
            }

            var postosComPrecoMenorOuIgual = _appDbContext.PostosDeAbastecimento.Where(x => x.PrecoGasolina <= precoGasolina).ToList();
            return postosComPrecoMenorOuIgual;
        }

        [HttpGet("Alcool-menor-que/{precoAlcool}")]
        public ActionResult<IEnumerable<PostoDeAbastecimento>> BuscarAlcoolMenorQue(decimal precoAlcool)
        {
            if (precoAlcool <= 0)
            {
                return BadRequest("O valor nao pode ser 0.");
            }

            var postosComPrecoMenorOuIgual = _appDbContext.PostosDeAbastecimento.Where(x => x.PrecoAlcool <= precoAlcool).ToList();
            return postosComPrecoMenorOuIgual;
        }

        [HttpGet("por-endereco/{endereco}")]
        public ActionResult<IEnumerable<PostoDeAbastecimento>> BuscarPorEndereco(string endereco){
            var postos = _appDbContext.PostosDeAbastecimento.Where(x => x.Endereco.Contains(endereco)).ToList();
            if(string.IsNullOrEmpty(endereco)){
                return BadRequest("O endereco não pode ser nulo ou vazio");
            }

            return Ok(postos);
        }


        [HttpPost]
        public async Task<ActionResult> Adicionar(PostoDeAbastecimento postoDeAbastecimento)
        {
            if(ModelState.IsValid){
            await _appDbContext.AddAsync(postoDeAbastecimento);
            await _appDbContext.SaveChangesAsync();
            return CreatedAtAction("BuscarPostoPorId", new { id = postoDeAbastecimento.Id }, postoDeAbastecimento);
            }
            
            return BadRequest(ModelState);
        }

        [HttpPut]
        public async Task<ActionResult> Atualizar(int id, PostoDeAbastecimento postoDeAbastecimento){

            var posto = _appDbContext.PostosDeAbastecimento.FirstOrDefault(x => x.Id == id);
            if(id == 0){
                return BadRequest("Valor não pode ser vazio ou nulo.");
            }

            posto.Nome = postoDeAbastecimento.Nome;
            posto.Cnpj = postoDeAbastecimento.Cnpj;
            posto.Endereco = postoDeAbastecimento.Endereco;
            posto.Banheiro = postoDeAbastecimento.Banheiro;
            posto.LavaJato = postoDeAbastecimento.LavaJato;
            posto.Calibrador = postoDeAbastecimento.Calibrador;
            posto.PrecoAlcool = postoDeAbastecimento.PrecoAlcool;
            posto.PrecoGasolina = postoDeAbastecimento.PrecoGasolina;
            posto.DataCadastro = posto.DataCadastro;
            

            _appDbContext.Update(posto);
            await _appDbContext.SaveChangesAsync();
            return Ok(posto);
        }

        [HttpDelete("Deletar-por-id/{id:int}")]
        public async Task<ActionResult> DeletarPorId(int id){
            var posto = _appDbContext.PostosDeAbastecimento.FirstOrDefault(x => x.Id == id);
            if(id == 0){
                return BadRequest("O id não pode ser 0 ou vazio");
            }

            _appDbContext.Remove(posto);
            await _appDbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("Deletar-por-cnpj/{cnpj}")]
        public async Task<ActionResult> DeletarPorCnpj(string cnpj){
            var posto = _appDbContext.PostosDeAbastecimento.FirstOrDefault(x => x.Cnpj == cnpj);
            if(string.IsNullOrEmpty(cnpj)){
                return BadRequest("O cnpj não pode ser 0 ou vazio");
            }

            _appDbContext.Remove(posto);
            await _appDbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
