package bg.softuni.lebank.dao;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.SQLException;

import org.springframework.stereotype.Repository;

import bg.softuni.lebank.interfaces.OperationsStorage;

@Repository
public class OperationsDao implements OperationsStorage {

	@Override
	public Boolean addOperation(
			String id,
			long accoungNo,
			String operation,
			String amount,
			String currency,
			String performedBy) {
		
		String sql = "INSERT INTO operations (id, account_no, operation, amount, currency, performed_by) VALUES (?,?,?,?,?,?)";		
		try (
				Connection connection = DbConnection.getConnection();
				PreparedStatement statement = connection.prepareCall(sql);) {
			statement.setString(1, id);
			statement.setLong(2, accoungNo);
			statement.setString(3, operation);
			statement.setString(4, amount);
			statement.setString(5, currency);
			statement.setString(6, performedBy);
			
			statement.executeQuery();
			
		} catch (SQLException e) {
			e.printStackTrace();
			return false;
		}
		
		return true;
	}
}
