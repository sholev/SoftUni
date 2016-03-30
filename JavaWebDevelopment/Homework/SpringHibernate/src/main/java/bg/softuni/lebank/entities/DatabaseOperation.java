package bg.softuni.lebank.entities;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table(name = "OPERATIONS")
public class DatabaseOperation {

	@Column(name = "ACCOUNT_NO")
	private long accountNumber;
	
	@Id
	@Column(name = "ID")
	private String selectedAccountId;
	
	@Column(name = "OPERATION")
	private String selectedOperation;
	
	@Column(name = "AMOUNT")
	private String operationAmmount;
	
	@Column(name = "CURRENCY")
	private String selectedCurrency;
	
	@Column(name = "PERFORMED_BY")
	private String performedBy;

	public DatabaseOperation() {	
		
	}
	
	public DatabaseOperation(
			long accountNumber,
			String selectedAccountId,
			String selectedOperation,
			String operationAmmount,
			String selectedCurrency,
			String performedBy) {
		
		this.setAccountNumber(accountNumber);
		this.setSelectedAccountId(selectedAccountId);
		this.setSelectedOperation(selectedOperation);
		this.setOperationAmmount(operationAmmount);
		this.setSelectedCurrency(selectedCurrency);
		this.setPerformedBy(performedBy);
	}

	public long getAccountNumber() {
		return accountNumber;
	}

	public String getSelectedAccountId() {
		return selectedAccountId;
	}

	public String getSelectedOperation() {
		return selectedOperation;
	}

	public String getOperationAmmount() {
		return operationAmmount;
	}

	public String getSelectedCurrency() {
		return selectedCurrency;
	}

	public String getPerformedBy() {
		return performedBy;
	}

	public void setAccountNumber(long accoungNumber) {
		this.accountNumber = accoungNumber;
	}	

	public void setSelectedAccountId(String selectedAccountId) {
		this.selectedAccountId = selectedAccountId;
	}

	public void setSelectedOperation(String selectedOperation) {
		this.selectedOperation = selectedOperation;
	}

	public void setOperationAmmount(String operationAmmount) {
		this.operationAmmount = operationAmmount;
	}

	public void setSelectedCurrency(String selectedCurrency) {
		this.selectedCurrency = selectedCurrency;
	}

	public void setPerformedBy(String performedBy) {
		this.performedBy = performedBy;
	}
}
