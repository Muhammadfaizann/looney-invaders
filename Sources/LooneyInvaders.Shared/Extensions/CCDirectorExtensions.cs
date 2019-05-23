using System;
using System.Threading.Tasks;
using CocosSharp;

namespace LooneyInvaders.Extensions
{
    public static class CCDirectorExtensions
    {
        public static async Task ReplaceSceneAsync(this CCDirector director, CCScene scene, bool resetSceneStack = false)
        {
            try
            {
                if (scene != null)
                {
                    await Task.Run(() =>
                    {
                        if (resetSceneStack)
                            director?.ResetSceneStack();
                        director?.ReplaceScene(scene);
                    });

                }
            }
            catch (Exception ex)
            {
                var mess = ex.Message;
                Console.WriteLine($"|ON ReplaceSceneAsync| Exception: {mess}");
            }
        }
    }

}
