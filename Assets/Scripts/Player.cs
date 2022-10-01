using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    [SerializeField] private GameController _gameController;
    [SerializeField] private UIManager _uIManager;
    [SerializeField] private GameObject _deathEffect;
    [SerializeField] private int _coins;
    [SerializeField] private float speed;
    [SerializeField] private PathMaker _pathMaker;
    [SerializeField] private List<Vector2> _touchPositions;

    private bool _pathCreated = false;

    public void SetTarget(Vector2 touchPosition)
    {
        if (_gameController.GameStarted)
        {
            _touchPositions.Add(touchPosition);
        }     
    }

    private void FixedUpdate()
    {
        if(_touchPositions.Count > 0 && _gameController.GameStarted)
        {
            Move();
        }   
    }

    public void Move()
    {
        Vector2 startPosition = transform.position;
        if (_pathCreated == false)
        {
            _pathMaker.SetupPath(startPosition, _touchPositions[0]);
            _pathCreated = true;
        }
        if (startPosition == _touchPositions[0])
        {
            _pathMaker.ResetPath();
            _touchPositions.Remove(_touchPositions[0]);
            _pathCreated = false;
        }
        else
        {
                  
            this.gameObject.transform.position = Vector2.Lerp(startPosition, _touchPositions[0], speed);
        }    
    }

    public void TakeCoin()
    {
        _coins++;
        _uIManager.AddCoin(_coins);
        if(_coins == 5)
        {
            _gameController.ChangeGameStatus();
            _uIManager.ShowVictoryScreen();
        }
    }

    public void TakeDamage()
    {
        _gameController.ChangeGameStatus();
        transform.DOScale(0.2f, 1).OnComplete(() =>
        {
            Instantiate(_deathEffect, transform.position, Quaternion.identity);
            _uIManager.ShowLoseScreen();
            Destroy(gameObject);
        });      
    }
}
