package bg.softuni.lebank.entities;

public class OperationInput {
	
	private String selectedAccountId;
	
	private String selectedOperation;
	
	private String operationAmmount;
	
	private String selectedCurrency;

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
}
