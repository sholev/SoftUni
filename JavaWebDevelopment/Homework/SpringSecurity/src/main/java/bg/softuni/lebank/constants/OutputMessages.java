package bg.softuni.lebank.constants;

public class OutputMessages {

	public static final String ENTER_NEW_ACCOUNT_INFO = 
			"Enter information for the new account.";
	
	public static final String ENTER_LOGIN_INFO =
			"Enter valid username and password:";

	public static final String INVALID_LOGIN_INFO =
			"Invalid username, try again:";
	
	public static final String INVALID_OPERATION = 
			"Make sure to select deposit or withdrawal and input a valid amount.";
	
	public static final String INVALID_WITHDRAWAL_AMOUNT = 
			"Invalid withdrawal amount. It should be greater than zero.";
	
	public static final String INVALID_CLIENT_ID = 
			"Invalid client id. The user does not have an account, deposit in order to create one.";
	
	public static final String INVALID_WITHDRAWAL_GREATER_THAN_BALLANCE = 
			"Invalid withdrawal amount. It should not be greater than the account ballance.";
	
	public static final String INVALID_WITHDRAWAL_ABOVE_DAILY_LIMIT = 
			"Invalid withdrawal amount. It's above the maximum daily withdrawal amount.";
	
	public static final String INVALID_DEPOSIT_NEGATIVE_OR_ZERO = 
			"Invalid deposit amount. It should be greater than zero.";

	public static final String INVALID_INITIAL_BALLANCE = 
			"Initial ballance should not be empty.";

	public static final String INVALID_ACCOUNT_ALREADY_EXISTS(String clientUsername, String accountId) {
		return "\"" + clientUsername + "\" already contains account with id: \"" + accountId + "\"";
	}
	
	public static final String SUCCESSFUL_WITHDRAW = 
			"Successully withdrawn: ";
	
	public static final String SUCCESSFUL_DEPOSIT = 
			"Successully deposited: ";
	
	public static final String SUCCESSFUL_DEPOSIT_AND_REGISTER = 
			"Successully created an account and deposited " ;

	public static final String SUCCESSFULL_ACCOUNT_ADDITION = 
			"Successfully added new accound for client username.";
	
	public static final String RGISTRY_INFORMATION = 
			"Banking information:";

	public static final String NO_ACCOUNTS_TO_DISPLAY = 
			"No banking accounts available to display. A bank employee can create accounts.";

	public static final String NO_ACCOUNTS_TO_OPERATE = 
			"No banking accounts to operate. A bank employee can create accounts.";

}
