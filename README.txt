# aspnetcore-api-test
Api Test
--Creates App Database.

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema testui
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema testui
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `testui` DEFAULT CHARACTER SET utf8 ;
USE `testui` ;

-- -----------------------------------------------------
-- Table `testui`.`sensordata`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `testui`.`sensordata` (
  `Id` INT(11) NOT NULL AUTO_INCREMENT,
  `Value1` INT(11) NOT NULL,
  `Value2` CHAR(1) CHARACTER SET 'utf8' COLLATE 'utf8_turkish_ci' NOT NULL,
  `CreateTime` DATETIME NOT NULL,
  `UpdateTime` DATETIME NOT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB
AUTO_INCREMENT = 2
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_turkish_ci;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
