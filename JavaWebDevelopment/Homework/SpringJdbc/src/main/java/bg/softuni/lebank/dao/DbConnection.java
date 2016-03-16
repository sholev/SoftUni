package bg.softuni.lebank.dao;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

import bg.softuni.lebank.constants.DbParams;

public class DbConnection {
	
	static {
		try {
			Class.forName(DbParams.DB_DRIVER);
		} catch (ClassNotFoundException e) {
			e.printStackTrace();
		}
	}
	
	public static Connection getConnection() {
		try {
			return DriverManager.getConnection(DbParams.URL, DbParams.USERNAME, DbParams.PASSWORD);
		} catch (SQLException e) {
			e.printStackTrace();
			return null;
		}		
	}
}
