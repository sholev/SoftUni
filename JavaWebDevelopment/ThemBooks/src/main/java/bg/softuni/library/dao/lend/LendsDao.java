package bg.softuni.library.dao.lend;

import java.util.Set;
import java.util.TreeSet;
import java.util.stream.Collectors;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.TypedQuery;
import javax.persistence.criteria.CriteriaBuilder;
import javax.persistence.criteria.CriteriaQuery;
import javax.persistence.criteria.Predicate;
import javax.persistence.criteria.Root;

import org.hibernate.Criteria;
import org.hibernate.HibernateException;
import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.Transaction;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

import bg.softuni.library.entity.lend.Lend;
import bg.softuni.library.interfaces.LendsStorage;

@Repository
public class LendsDao implements LendsStorage {
	
	@Autowired
	SessionFactory sessionFactory;

	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public Set<Lend> getLends() {
		Set<Lend> lends = new TreeSet<>();
		
		Criteria criteria = sessionFactory
				.openSession()
				.createCriteria(Lend.class);
		
		for (Object user : criteria.list()) {				
			lends.add((Lend)user);
		}
	
		return lends;
	}

	@Override
	public Set<Lend> getLends(Lend search) {
		CriteriaBuilder criteriaBuilder = entityManager.getCriteriaBuilder();
		CriteriaQuery<Lend> criteriaQuery = criteriaBuilder.createQuery(Lend.class);
		Root<Lend> from = criteriaQuery.from(Lend.class);

		Predicate predicate1 = criteriaBuilder.and();
		Predicate predicate2 = criteriaBuilder.and();
		Predicate predicate3 = criteriaBuilder.and();
		Predicate predicate4 = criteriaBuilder.and();
		if (search.getBookId() != null) {
			predicate1 = from.get("bookId").in(search.getBookId());
		}
		if (search.getClientId() != null) {
			predicate2 = from.get("clientId").in(search.getClientId());
		}
		if (search.getLendDate() != null) {
			predicate3 = from.get("lendDate").in(search.getLendDate());
		}	
		if (search.getReturnDate() != null) {
			predicate4 = from.get("returnDate").in(search.getReturnDate());
		}		
		criteriaQuery.where(predicate1, predicate2, predicate3, predicate4);

		criteriaQuery.select(from);
		TypedQuery<Lend> query = entityManager.createQuery(criteriaQuery);
		
		return query.getResultList().stream()
				.collect(Collectors.toCollection(() -> new TreeSet<Lend>()));
	}
	
	@Override
	public boolean addLend(Lend lend) {
		Transaction transaction = null;
		try (Session session = this.sessionFactory.openSession();) {			
			transaction = session.beginTransaction();
			
			session.save(lend);
			
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
	public boolean editLend(Long lendId, Lend updatedLend) {
		Transaction transaction = null;
		try (Session session = this.sessionFactory.openSession();) {			
			transaction = session.beginTransaction();
			
			Lend lend = session.load(Lend.class, lendId);
			lend = updatedLend;
			session.update(lend);
			
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
