package bg.softuni.lebank.dao;

import java.math.BigDecimal;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import org.springframework.stereotype.Repository;

import bg.softuni.lebank.entities.ClientAccount;
import bg.softuni.lebank.entities.DisplayData;
import bg.softuni.lebank.interfaces.AccountData;
import bg.softuni.lebank.interfaces.AccountsStorage;

@Repository
public class AccountsDao implements AccountsStorage {
	
	@Override
	public Boolean addAccount(
			String id,
			long accoungNo,
			String username,
			String amount,
			String currency,
			String createdBy) {
		
		String sql = "INSERT INTO accounts (id, account_no, username, amount, currency, created_by) VALUES (?,?,?,?,?,?)";		
		try (
				Connection connection = DbConnection.getConnection();
				PreparedStatement statement = connection.prepareCall(sql);) {
			statement.setString(1, id);
			statement.setLong(2, accoungNo);
			statement.setString(3, username);
			statement.setString(4, amount);
			statement.setString(5, currency);
			statement.setString(6, createdBy);
			
			statement.executeQuery();
			
		} catch (SQLException e) {
			e.printStackTrace();
			return false;
		}
		
		return true;
	}
	
	@Override
	public Boolean updateAccount(String accountId, String amount) {
		
		String sql = "UPDATE accounts SET amount = ? WHERE id = ?";		
		try (
				Connection connection = DbConnection.getConnection();
				PreparedStatement statement = connection.prepareCall(sql);) {
			
				statement.setString(1, amount);
				statement.setString(2, accountId);
				
				statement.executeQuery();
				
		} catch (SQLException e) {
			e.printStackTrace();
			return false;
		}
		return true;
	}
	
	@Override
	public DisplayData[] getAccountDisplayData(String[] accountIds) {
		List<String> ids = Arrays.asList(accountIds);
		List<DisplayData> displayData = new ArrayList<>();
		
		try (
				Connection connection = DbConnection.getConnection();
				Statement statement = connection.createStatement();) {
			
			String sql = "SELECT * FROM accounts";
			
			ResultSet result = statement.executeQuery(sql);
			
			while(result.next()) {				
				String id = result.getString("id");
				if (ids.contains(id)) {

					// TODO: Add the additional information in DisplayData
					
					//Long accountNo = result.getLong("accountNo");				
					//String username = result.getString("username");
					String amount = result.getString("amount");
					String currency = result.getString("currency");
					//String createdBy = result.getString("createdBy");

					displayData.add(new DisplayData(id, amount, currency));
				}
			}
			
		} catch (SQLException e) {
			e.printStackTrace();
			return null;
		}
		
		if (ids.size() == 0 || displayData.size() == 0) {
			return null;
		}
		
		return displayData.toArray(new DisplayData[0]);
	}

	@Override
	public Map<String, AccountData> getAccounts() {
		Map<String, AccountData> accounts = new HashMap<>();
		
		try (
				Connection connection = DbConnection.getConnection();
				Statement statement = connection.createStatement();) {
			
			String sql = "SELECT * FROM accounts";
			
			ResultSet result = statement.executeQuery(sql);
			
			while(result.next()) {
				String id = result.getString("id");
				String amount = result.getString("amount");
				String currency = result.getString("currency");

				accounts.put(id, new ClientAccount(new BigDecimal(amount), currency));
			}
			
		} catch (SQLException e) {
			e.printStackTrace();
			return null;
		}
		
		if (accounts.isEmpty()) {
			return null;
		}
		
		return accounts;
	}

	@Override
	public String[] getUserIds(String clientUsername) {
		List<String> ids = new ArrayList<>();
		
		String sql = "SELECT id FROM accounts WHERE username = ?";		
		try (
				Connection connection = DbConnection.getConnection();
				PreparedStatement statement = connection.prepareCall(sql);) {
			
			statement.setString(1, clientUsername);
			
			ResultSet result = statement.executeQuery();
			
			while(result.next()) {	
				String id = result.getString("id");				
				ids.add(id);
			}
			
		} catch (SQLException e) {
			e.printStackTrace();
			return null;
		}
		
		if (ids.size() == 0) {
			return null;
		}
		
		return ids.toArray(new String[0]);
	}

	@Override
	public String[] getAllIds() {
		List<String> ids = new ArrayList<>();		
		try (
				Connection connection = DbConnection.getConnection();
				Statement statement = connection.createStatement();) {
			
			String sql = "SELECT id FROM accounts";
			
			ResultSet result = statement.executeQuery(sql);
			
			while(result.next()) {				
				String id = result.getString("id");

				ids.add(id);

			}
			
		} catch (SQLException e) {
			e.printStackTrace();
			return null;
		}
		
		if (ids.size() == 0) {
			return null;
		}
		
		return ids.toArray(new String[0]);
	}
}
