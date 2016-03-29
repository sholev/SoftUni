package bg.softuni.lebank.dao;

import org.hibernate.HibernateException;
import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.Transaction;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;
import org.springframework.transaction.annotation.Transactional;

import bg.softuni.lebank.entities.OperationInput;
import bg.softuni.lebank.interfaces.OperationsStorage;

@Repository
public class OperationsDao implements OperationsStorage {

	@Autowired
	private SessionFactory sessionFactory;
	
	@Override
	@Transactional
	public Boolean addOperation(
			String id,
			long accountNo,
			String operation,
			String amount,
			String currency,
			String performedBy) {

		OperationInput operationData = new OperationInput(
				accountNo, id, operation, amount, currency, performedBy);
		
		Transaction transaction = null;
		try (Session session = this.sessionFactory.openSession();) {			
			transaction = session.beginTransaction();
			session.save(operationData);
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
}
