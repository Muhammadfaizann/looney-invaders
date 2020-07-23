using System.Threading;

namespace LooneyInvaders.Extensions
{
    public class CustomCancellationTokenSource : CancellationTokenSource
    {
        public bool IsDead { get; set; }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            IsDead = true;
        }
    }
}