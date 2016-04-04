package bg.softuni.lebank.entities;

public class InputData {

	private String clientId;
	private String selectedOperation;
	private String operationAmount;
	private String selectedCurrency;
	private String currentBallance;
	
	public String getClientId() {
		return clientId;
	}
	
	public String getSelectedOperation() {
		return selectedOperation;
	}
	
	public String getOperationAmount() {
		return operationAmount;
	}
	
	public String getSelectedCurrency() {
		return selectedCurrency;
	}
	
	public String getCurrentBallance() {
		return currentBallance;
	}
	
	public void setClientId(String clientId) {
		this.clientId = clientId;
	}
	
	public void setSelectedOperation(String selectedOperation) {
		this.selectedOperation = selectedOperation;
	}
	
	public void setOperationAmount(String operationAmount) {
		this.operationAmount = operationAmount;
	}
	
	public void setSelectedCurrency(String selectedCurrency) {
		this.selectedCurrency = selectedCurrency;
	}
	
	public void setCurrentBallance(String currentBallance) {
		this.currentBallance = currentBallance;
	}	
}
