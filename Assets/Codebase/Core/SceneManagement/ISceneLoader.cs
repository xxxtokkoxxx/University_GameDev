
using System.Threading.Tasks;

namespace Codebase.Core.SceneManagement
{
    public interface ISceneLoader
    {
        Task LoadScene(string sceneName);
    }
}