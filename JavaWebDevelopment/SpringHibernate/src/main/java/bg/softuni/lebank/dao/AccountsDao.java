package bg.softuni.lebank.dao;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import org.hibernate.Criteria;
import org.hibernate.HibernateException;
import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.Transaction;
import org.hibernate.criterion.Property;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

import bg.softuni.lebank.entities.DatabaseAccount;
import bg.softuni.lebank.entities.ClientAccount;
import bg.softuni.lebank.entities.DisplayData;
import bg.softuni.lebank.interfaces.AccountData;
import bg.softuni.lebank.interfaces.AccountStorage;

@Repository
public class AccountsDao implements AccountStorage {

	@Autowired
	private SessionFactory sessionFactory;
	
	@Override
	public Boolean addAccount(DatabaseAccount accountData) {
		
		
		Transaction transaction = null;
		try (Session session = this.sessionFactory.openSession();) {			
			transaction = session.beginTransaction();
			
			session.save(accountData);
			
			transaction.commit();
			
		} catch (HibernateException e) {
			if (transaction != null) {
				transaction.rollback();
			}
			e.printStackTrace();
			
			return false;
		}
		
		return true;
	}
	
	@Override
	public Boolean updateAccount(String accountId, String amount) {
		
		Transaction transaction = null;
		try (Session session = this.sessionFactory.openSession();) {			
			transaction = session.beginTransaction();
			
			DatabaseAccount accountData = session.load(DatabaseAccount.class, accountId);
			accountData.setAmount(amount);
			session.update(accountData);
			
			transaction.commit();	
			
		} catch (HibernateException e) {
			if (transaction != null) {
				transaction.rollback();
			}
			e.printStackTrace();
			
			return false;
		}
		
		return true;
	}
	
	@Override
	public List<DisplayData> getAccountDisplayData(List<String> accountIds) {
		if (accountIds.size() == 0) {
			return null;
		}
		
		List<DisplayData> displayData = new ArrayList<>();
		
		Criteria criteria = this.sessionFactory
				.openSession()
				.createCriteria(DatabaseAccount.class);	
		
		criteria.add(Property.forName("id").in(accountIds));
		
		for (Object obj : criteria.list()) {
			DatabaseAccount acc = (DatabaseAccount)obj;		
			displayData.add(
					new DisplayData(acc.getId(), acc.getAmount(), acc.getCurrency()));
		}
		
		if (displayData.size() == 0) {
			return null;
		}
		
		return displayData;
	}

	@Override
	public Map<String, AccountData> getAccounts() {
		Map<String, AccountData> accounts = new HashMap<>();
		
		Criteria criteria = this.sessionFactory
				.openSession()
				.createCriteria(DatabaseAccount.class);	
		
		for (Object obj : criteria.list()) {
			DatabaseAccount acc = (DatabaseAccount)obj;
			
			accounts.put(
					acc.getId(),
					new ClientAccount(new BigDecimal(acc.getAmount()), acc.getCurrency()));
		}
		
		if (accounts.isEmpty()) {
			return null;
		}
		
		return accounts;
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<String> getUserIds(String clientUsername) {
		List<String> ids = new ArrayList<>();
		
		this.sessionFactory.openSession()
			.createCriteria(DatabaseAccount.class)
			.add(Property.forName("username").in(clientUsername))
			.list()
			.forEach(acc -> ids.add(((DatabaseAccount) acc).getId()));
		
		if (ids.size() == 0) {
			return null;
		}
		
		return ids;
	}

	
	@SuppressWarnings("unchecked")
	@Override
	public List<String> getAllIds() {
		List<String> ids = new ArrayList<>();	
		
		this.sessionFactory.openSession()
			.createCriteria(DatabaseAccount.class)
			.list().forEach(acc -> ids.add(((DatabaseAccount)acc).getId()));
		
		if (ids.size() == 0) {
			return null;
		}
		
		return ids;
	}
}
