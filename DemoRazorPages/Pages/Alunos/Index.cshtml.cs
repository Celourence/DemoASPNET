using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DemoRazorPages.Pages.Alunos
{
    public class IndexModel : PageModel
    {
        private readonly DemoRazorPages.Data.ApplicationDbContext _context;

        public IndexModel(DemoRazorPages.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Aluno> Aluno { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Aluno = await _context.Aluno.ToListAsync();
        }
    }
}
