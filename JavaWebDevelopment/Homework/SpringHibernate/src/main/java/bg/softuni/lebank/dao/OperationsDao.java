package bg.softuni.lebank.dao;

import org.hibernate.HibernateException;
import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.Transaction;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

import bg.softuni.lebank.entities.DatabaseOperation;
import bg.softuni.lebank.interfaces.OperationStorage;

@Repository
public class OperationsDao implements OperationStorage {

	@Autowired
	private SessionFactory sessionFactory;
	
	@Override
	public Boolean addOperation(DatabaseOperation operationData) {
		
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
