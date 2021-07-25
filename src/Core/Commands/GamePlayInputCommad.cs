using Core.Commands.Base;

namespace Core.Commands
{
    public class GamePlayInputCommand : IBaseInputCommand
    {
        public class GameExit : GamePlayInputCommand { }
        public class GamePause : GamePlayInputCommand { }
        public class PlayerMoveLeft : GamePlayInputCommand { }
        public class PlayerMoveRight : GamePlayInputCommand { }
        public class PlayerMoveUp : GamePlayInputCommand { }
        public class PlayerMoveDown : GamePlayInputCommand { }
        public class PlayerShoots : GamePlayInputCommand { }
    }
}