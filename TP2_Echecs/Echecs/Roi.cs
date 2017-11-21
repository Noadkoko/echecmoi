﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2_Echecs.IHM;

namespace TP2_Echecs.Echecs
{
    class Roi : Piece
    {
        public Roi(Joueur joueur) : base(joueur, TypePiece.Roi)
        {
        }

        public override bool Deplacer(Case destination)
        {
            destination.Link(this);

            int diffColonne = Math.Abs(destination.colonne - this.position.colonne);
            int diffRangee = Math.Abs(destination.rangee - this.position.rangee);

            return diffColonne == 1 && diffRangee == 1;            
        }
    }
}
