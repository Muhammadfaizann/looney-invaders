using System.Threading;

namespace LooneyInvaders.Classes
{
    public class CustomCancellationTokenSource : CancellationTokenSource
    {
        public bool IsDead { get; set; }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            IsDead = true;
        }

        public new void Cancel()
        {
            if (!IsDead)
            {
                base.Cancel();
            }
        }
    }
}