package bg.softuni.lebank.entities;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table(name = "ACCOUNTS")
public class DatabaseAccount {
	
	@Id
	@Column(name = "ID")
	private String id;
	
	@Column(name = "ACCOUNT_NO")
	private long accountNo;
	
	@Column(name = "USERNAME")
	private String username;

	@Column(name = "AMOUNT")
	private String amount;
	
	@Column(name = "CURRENCY")
	private String currency;
	
	@Column(name = "CREATED_BY")
	private String createdBy;
		
	public DatabaseAccount() {
		
	}
	
	public DatabaseAccount(
			String id,
			long accountNo,
			String username,
			String amount,
			String currency,
			String createdBy) {
		
		this.setId(id);
		this.setAccountNo(accountNo);
		this.setUsername(username);
		this.setAmount(amount);
		this.setCurrency(currency);
		this.setCreatedBy(createdBy);
	}

	public String getId() {
		return id;
	}

	public long getAccountNo() {
		return accountNo;
	}

	public String getUsername() {
		return username;
	}

	public String getAmount() {
		return amount;
	}

	public String getCurrency() {
		return currency;
	}

	public String getCreatedBy() {
		return createdBy;
	}

	public void setId(String id) {
		this.id = id;
	}

	public void setAccountNo(long accountNo) {
		this.accountNo = accountNo;
	}

	public void setUsername(String username) {
		this.username = username;
	}

	public void setAmount(String amount) {
		this.amount = amount;
	}

	public void setCurrency(String currency) {
		this.currency = currency;
	}

	public void setCreatedBy(String createdBy) {
		this.createdBy = createdBy;
	}	
}
