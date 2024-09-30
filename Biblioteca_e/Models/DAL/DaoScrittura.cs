using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_e.Models.DAL
{
    internal interface DaoScrittura
    {
        public static void AddLibro(string titolo, DateOnly DataPublicazione, bool disponibilita)
        {
            Libro book = new Libro()
            {
                Titolo = titolo,
                AnnoPubblicazione = DataPublicazione,
                Disponibilita = disponibilita

            };
            using (var ctx = new BibliotecaContext())
            {
                try
                {
                    ctx.Libros.Add(book);
                    ctx.SaveChanges();
                    disponibilita = true;

                    Console.WriteLine("libro inserito con successo");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


                static void AddUtente(string nome, string cognome, string email)
                {


                    Utente User = new Utente()
                    {
                        Nome = nome,
                        Cognome = cognome,
                        Email = email
                    };

                    using (var ctx = new BibliotecaContext())
                    {

                        try
                        {
                            ctx.Utentes.Add(User);
                            ctx.SaveChanges();

                            Console.WriteLine("Utente inserito con successo");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }


                static void AddPrestito(DateOnly dataConsegna, DateOnly dataRitiro,
                                                int utenteId, int libroId)
                {

                    Prestito prestit = new Prestito()
                    {
                        DataConsegna = dataConsegna,
                        DataRitiro = dataRitiro,
                        UtenteRif = utenteId,
                        LibroRif = libroId,
                    };

                    using (var ctx = new BibliotecaContext())
                    {
                        try
                        {
                            if (Libros.Disponibilita == false)
                            {
                                ctx.Prestitos.Add(prestit);
                                ctx.SaveChanges();
                                Console.WriteLine("Prestito inserito con successo");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                    }
                }
            }
        }
    }
}
