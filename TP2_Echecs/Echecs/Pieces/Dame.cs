﻿using System;
using TP2_Echecs.IHM;

namespace TP2_Echecs.Echecs
{
    public class Dame : Piece
    {
        public Dame(Joueur joueur) : base(joueur, TypePiece.Dame) { }

        public override bool Deplacer(Case destination)
        {
            if (DeplacerSurAllie(destination)) return false;

            bool result = true;

          int diffColonne = destination.colonne - this.position.colonne;
          int diffRangee = destination.rangee - this.position.rangee;
          int i = 0;

          if (diffColonne == diffRangee)
          {
              while(Math.Abs(diffColonne) != i)
              {
                  if (joueur.partie.echiquier.cases[i + this.position.rangee, i + this.position.colonne] != null)
                  {
                      return false;
                  }
                  ++i;
              }
          }

          if (diffColonne != 0 && diffRangee == 0)
          {
              while (Math.Abs(diffColonne) != i)
              {
                  if (joueur.partie.echiquier.cases[this.position.rangee, i + this.position.colonne] != null)
                  {
                      return false;
                  }
                  ++i;
              }
          }

          if (diffColonne == 0 && diffRangee != 0)
          {
              while (Math.Abs(diffRangee) != i)
              {
                  if (joueur.partie.echiquier.cases[this.position.rangee, this.position.colonne] != null)
                  {
                      return false;
                  }
                  ++i;
              }
            }

            if (result)
            {
                destination.Link(this);
                this.position.Unlink();
            }

            return result;
        }
    }
}