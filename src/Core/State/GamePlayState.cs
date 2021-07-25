using System;
using System.Collections.Generic;
using Core.Commands;
using Core.Inputs.Base;
using Core.Mappers;
using Core.Objects;
using Core.State.Base;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Core.State
{
    public class GamePlayState : BaseGameState
    {
        private const string PlayerFighter = "Fighter";
        private const string BulletTexture = "bullet";
        private Texture2D _bulletTexture;
        private List<BulletSprite> _bulletList;
        private PlayerSprite _playerSprite;
        private const string BackgroundTexture = "Barren";
        private bool _isShooting;
        private TimeSpan _lastShotAt;

        public override void HandleInput(GameTime gameTime)
        {
            BaseInputManager.GetCommands(command =>
            {
                if (command is GamePlayInputCommand.GameExit)
                {
                    NotifyEvent(Events.GAME_QUIT);
                }
                if (command is GamePlayInputCommand.GamePause)
                {
                    NotifyEvent(Events.GAME_PAUSE);
                }
                if (command is GamePlayInputCommand.PlayerMoveLeft)
                {
                    _playerSprite.MoveLeft();
                    KeepPlayerInBounds();
                }
                if (command is GamePlayInputCommand.PlayerMoveRight)
                {
                    _playerSprite.MoveRight();
                    KeepPlayerInBounds();
                }
                if (command is GamePlayInputCommand.PlayerMoveUp)
                {
                    _playerSprite.MoveUp();
                    KeepPlayerInBounds();
                }
                if (command is GamePlayInputCommand.PlayerMoveDown)
                {
                    _playerSprite.MoveDown();
                    KeepPlayerInBounds();
                }

                if (command is GamePlayInputCommand.PlayerShoots)
                {
                    Shoot(gameTime);
                }
            });
        }

        private void Shoot(GameTime gameTime)
        {
            if (!_isShooting)
            {
                CreateBullets();
                _isShooting = true;
                _lastShotAt = gameTime.TotalGameTime;
            }
        }

        private void CreateBullets()
        {
            var bulletSpriteLeft = new BulletSprite(_bulletTexture);
            var bulletSpriteRight = new BulletSprite(_bulletTexture);
            var bulletY = _playerSprite.Position.Y + 30;
            var bulletLeftX = _playerSprite.Position.X + _playerSprite.Width / 2 - 40;
            var bulletRightX = _playerSprite.Position.X + _playerSprite.Width /2 + 10;
            
            bulletSpriteLeft.Position = new Vector2(bulletLeftX, bulletY);
            bulletSpriteRight.Position = new Vector2(bulletRightX, bulletY);

            _bulletList.Add(bulletSpriteLeft);
            _bulletList.Add(bulletSpriteRight);

            AddGameObject(bulletSpriteLeft);
            AddGameObject(bulletSpriteRight);

        }

        public override void LoadContent()
        {
            _playerSprite = new PlayerSprite(LoadTexture(@"GameStates\GamePlay\" + PlayerFighter));
            _bulletTexture = LoadTexture(@"GameStates\GamePlay\" + BulletTexture);
            _bulletList = new List<BulletSprite>();


            AddGameObject(new TerrainBackground(LoadTexture(@"GameStates\GamePlay\" + BackgroundTexture)));

            AddGameObject(_playerSprite);

            var playerXPos = _viewportWidth / 2 - _playerSprite.Width / 2;
            var playerYPos = _viewportHeight - _playerSprite.Height - 30;
            _playerSprite.Position = new Vector2(playerXPos, playerYPos);
        }

        protected override void SetInputManager()
        {
            BaseInputManager = new BaseInputManager(new GamePlayInputMapper());
        }

        private void KeepPlayerInBounds()
        {
            if (_playerSprite.Position.X < 0)
            {
                _playerSprite.Position = new Vector2(0, _playerSprite.Position.Y);
            }
            if (_playerSprite.Position.X > _viewportWidth - _playerSprite.Width)
            {
                _playerSprite.Position = new Vector2(_viewportWidth - _playerSprite.Width, _playerSprite.Position.Y);
            }
            if (_playerSprite.Position.Y < 0)
            {
                _playerSprite.Position = new Vector2(_playerSprite.Position.X, 0);
            }
            if (_playerSprite.Position.Y > _viewportHeight - _playerSprite.Height)
            {
                _playerSprite.Position = new Vector2(_playerSprite.Position.X, _viewportHeight - _playerSprite.Height);
            }
        }

        public override void Update(GameTime gameTime)
        {
           foreach(var bullet in _bulletList)
           {
               bullet.MoveUp();
           }

           if(_lastShotAt != null && gameTime.TotalGameTime - _lastShotAt > TimeSpan.FromSeconds(.2))
           {
               _isShooting = false;
           }

            var newBulletList = new List<BulletSprite>();
            foreach (var bullet in _bulletList)
            {
                var bulletStillOnScreen = bullet.Position.Y > -30;

                if (bulletStillOnScreen)
                {
                    newBulletList.Add(bullet);
                }
                else
                {
                    RemoveGameObject(bullet);
                }
            }
            _bulletList = newBulletList;
        }
    }
}