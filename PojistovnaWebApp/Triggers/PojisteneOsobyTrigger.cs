using PojistovnaWebApp.Data;
using PojistovnaWebApp.Models;
using EntityFrameworkCore.Triggered;
using Microsoft.EntityFrameworkCore;
/*
 * "Before safe" trigger pro pojistnou událost
 * Trigger ověřuje, zda plnění pojištění "Plneni" v pojistné události není větší než pojištěná částka ve sjednaném pojištění.
 * Pokud je plnění větší než pojištěná částka, trigger uloží změny do databáze. Pokud tomu tak není, trigger se nespustí a změny se neuloží.
 */
namespace PojistovnaWebApp.Triggers
{
    public class PojisteneOsobyTrigger : IBeforeSaveTrigger<PojistnaUdalost>
    {
        private readonly ApplicationDbContext db;

        public async Task BeforeSave(ITriggerContext<PojistnaUdalost> context, CancellationToken cancellationToken)
        {
            if (context.ChangeType == ChangeType.Added || context.ChangeType == ChangeType.Modified)
            {
                PojistnaUdalost PojistnaUdalost = context.Entity;

                SjednanaPojisteni SjednanaPojisteni = await db.SjednanaPojisteni.FirstOrDefaultAsync(i => i.Id == PojistnaUdalost.SjednanaPojisteniId);

                if (PojistnaUdalost.Plneni! > SjednanaPojisteni.PojistnaCastka)
                {
                    await db.SaveChangesAsync();
                }
            }
        }
    }
}

