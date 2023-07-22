using EntityFrameworkCore.Triggered;
using PojistovnaWebApp.Data;
using PojistovnaWebApp.Models;
using System.Text;
/*
 * Implementuce triggeru pro třídu PojistneOsoby (BeforeSave) do databáze a pomocí StringBuilder sestavuje celé jméno ze jména a příjmení.
 * Ukládá ho do vlastnosti CeleJmeno modelu PojistneOsoby. Po dokončení se trigger vrací úspěšné dokončení úlohy pomocí Task.CompletedTask. 
 */


namespace PojistovnaWebApp.Triggers
{
    public class PojistnaUdalostTrigger : IBeforeSaveTrigger<PojisteneOsoby>
    {
        private readonly ApplicationDbContext db;

        public string CeleJmeno { get; private set; }

        public Task BeforeSave(ITriggerContext<PojisteneOsoby> context, CancellationToken cancellationToken)
        {
            if (context.ChangeType == ChangeType.Added || context.ChangeType == ChangeType.Modified)
            {
                PojisteneOsoby PojisteneOsoby = context.Entity;

                CeleJmeno = new StringBuilder()
                    .Append(' ')
                    .Append(PojisteneOsoby.Jmeno)
                    .Append(' ')
                    .Append(PojisteneOsoby.Prijmeni)
                    .ToString()
                    .Trim();
            }
            return Task.CompletedTask;
        }
    }
}
