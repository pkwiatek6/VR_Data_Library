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
  con.query("SELECT * FROM Test_Games", function (err, result, fields) {
    if (err) throw err;
    res.send(result);
  });
});

/* GET api listing. */
router.get('/users', function (req, res, next) {
  con.query("SELECT * FROM Test_Games", function (err, result, fields) {
    if (err) throw err;
    res.send(result);
  });
});

/* GET api listing. */
router.get('/admins', function (req, res, next) {
  con.query("SELECT * FROM Test_Administrators", function (err, result, fields) {
    if (err) throw err;
    res.send(result);
  });
});

/* GET api listing. */
router.get('/events', function (req, res, next) {
  res.sendFile('events.html', {
    root: path.resolve(__dirname, '../public')
  });
});

/* POST api method route */
router.post('/games', function (res, req) {
  console.log (req.body);
  res.send('POST Request received');
});

module.exports = router;
