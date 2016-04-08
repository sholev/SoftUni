package bg.softuni.library.dao.book;

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

import bg.softuni.library.dto.book.BookSearch;
import bg.softuni.library.entities.book.Book;
import bg.softuni.library.interfaces.BooksStorage;

@Repository
public class BooksDao implements BooksStorage {

	@Autowired
	SessionFactory sessionFactory;

	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public Set<Book> getBooks() {
		Set<Book> books = new TreeSet<>();
		
		Criteria criteria = sessionFactory
				.openSession()
				.createCriteria(Book.class);
		
		for (Object user : criteria.list()) {				
			books.add((Book)user);
		}
	
		return books;
	}

	@Override
	public Set<Book> getBooks(BookSearch search) {
		CriteriaBuilder criteriaBuilder = entityManager.getCriteriaBuilder();
		CriteriaQuery<Book> criteriaQuery = criteriaBuilder.createQuery(Book.class);
		Root<Book> from = criteriaQuery.from(Book.class);

		Predicate predicate1 = criteriaBuilder.and();
		Predicate predicate2 = criteriaBuilder.and();
		Predicate predicate3 = criteriaBuilder.and();
		if (search.getName() != null && !search.getName().isEmpty()) {
			predicate1 = from.get("name").in(search.getName());
		}
		if (search.getAuthor() != null && !search.getAuthor().isEmpty()) {
			predicate2 = from.get("author").in(search.getAuthor() );
		}
		if (search.getPublishDate() != null) {
			predicate3 = from.get("publishDate").in(search.getPublishDate());
		}
		criteriaQuery.where(predicate1, predicate2, predicate3);

		criteriaQuery.select(from);
		TypedQuery<Book> query = entityManager.createQuery(criteriaQuery);
		
		return query.getResultList().stream()
				.collect(Collectors.toCollection(() -> new TreeSet<Book>()));
	}

	@Override
	public boolean addBook(Book book) {
		Transaction transaction = null;
		try (Session session = this.sessionFactory.openSession();) {			
			transaction = session.beginTransaction();
			
			session.save(book);
			
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
	public boolean deleteBook(Book book) {
		Transaction transaction = null;
		try (Session session = this.sessionFactory.openSession();) {			
			transaction = session.beginTransaction();
			
			session.delete(book);
			
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
	public boolean editBook(Long bookId, Book updatedBook) {
		Transaction transaction = null;
		try (Session session = this.sessionFactory.openSession();) {			
			transaction = session.beginTransaction();
			
			Book book = session.load(Book.class, bookId);
			book = updatedBook;
			session.update(book);
			
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
