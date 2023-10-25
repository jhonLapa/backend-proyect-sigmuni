using Jca.Sigmuni.Domain.Admins;
using Jca.Sigmuni.Domain.Base;

namespace Jca.Sigmuni.Domain.General
{
    public class Perfil : ModelBase<int>
    {
        public string Etiqueta { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
