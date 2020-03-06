var express = require('express');
var router = express.Router();
var mysql = require('mysql');
var path = require('path');

var con = mysql.createPool({
  password: 'Secure_123',
  user: 'dushar88',
  host: 'ec2-54-208-235-237.compute-1.amazonaws.com',
  port: 3306,
  database: 'VR_DATA'
});

/* GET api listing. */
router.get('/', function (req, res, next) {
  res.send('api got a request at base level');
});

/* GET api listing. */
router.get('/games', function (req, res, next) {
  con.query("CALL get_games()", function (err, result, fields) {
    if (err) throw err;
    res.send(result);
  });
});

/* GET api listing. */
router.get('/users', function (req, res, next) {
  con.query("CALL get_subjects()", function (err, result, fields) {
    if (err) throw err;
    res.send(result);
  });
});

/* GET api listing. */
router.get('/admins', function (req, res, next) {
  con.query("CALL get_admins()", function (err, result, fields) {
    if (err) throw err;
    res.send(result);
  });
});

/* GET api listing. */
router.get('/events', function (req, res, next) {
  con.query("CALL get_events()", function (err, result, fields) {
    if (err) throw err;
    res.send(result);
  });
});

/* POST api method route */
router.post('/events/', function ({ body }, res, next) {
  const {
    subject_id,
    admin_id,
    game_id,
    event_data
  } = body;
  let sql = 'CALL create_event(?,?,?,?)';
  con.query(sql, [subject_id, admin_id, game_id, JSON.stringify(event_data)], function (err, result, fields) {
    if (err) res.send(err);
    res.send('successfully created event');
  });
});


/* POST api method route */
router.post('/games/', function ({ body }, res, next) {
  const {
    game_name
  } = body;

  let sql = 'CALL create_game(?)';
  con.query(sql, game_name, function (err, result, fields) {
    if (err) res.send('error occurred in create_game');
    res.send('successfully created game'); //TODO ROUTE SOMEWHERE USEFUL
  });
});

/* POST api method route */
router.post('/admins/', function ({ body }, res, next) {
  const {
    game_name
  } = body;

  let sql = 'CALL create_admin(?)';
  con.query(sql, game_name, function (err, result, fields) {
    if (err) res.send('error occurred in create_admin');
    res.send('successfully created admin'); //TODO ROUTE SOMEWHERE USEFUL
  });
});

/* POST api method route */
router.post('/users/', function ({ body }, res, next) {
  const {
    game_name
  } = body;

  let sql = 'CALL create_subject(?)';
  con.query(sql, game_name, function (err, result, fields) {
    if (err) res.send('error occurred in create_subject');
    res.send('successfully created subject'); //TODO ROUTE SOMEWHERE USEFUL
  });
});

module.exports = router;
