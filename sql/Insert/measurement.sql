LOAD DATA LOCAL INFILE "/tmp/sql/insert/measurementsDownfall.bulk" INTO TABLE measurement
FIELDS TERMINATED BY ', ' ENCLOSED BY "'"
LINES TERMINATED BY '\r\n';

LOAD DATA LOCAL INFILE "/tmp/sql/insert/measurementsHumidity.bulk" INTO TABLE measurement
FIELDS TERMINATED BY ', ' ENCLOSED BY "'"
LINES TERMINATED BY '\r\n';

LOAD DATA LOCAL INFILE "/tmp/sql/insert/measurementsTemperature.bulk" INTO TABLE measurement
FIELDS TERMINATED BY ', ' ENCLOSED BY "'"
LINES TERMINATED BY '\r\n';