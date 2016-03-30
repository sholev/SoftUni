package bg.softuni.lebank.controllers;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.core.Authentication;
import org.springframework.security.core.GrantedAuthority;
import org.springframework.security.core.context.SecurityContext;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;

import bg.softuni.lebank.constants.OutputMessages;
import bg.softuni.lebank.entities.DatabaseAccount;
import bg.softuni.lebank.entities.DisplayData;
import bg.softuni.lebank.entities.NewAccountInput;
import bg.softuni.lebank.entities.DatabaseOperation;
import bg.softuni.lebank.interfaces.AccountService;
import bg.softuni.lebank.interfaces.AccountStorage;
import bg.softuni.lebank.interfaces.UserStorage;

@Controller
public class BankingController {
	
	// AccountService should most likely handle AccountsStorage,
	// however this is the result of initial bad design 
	// and lack of foresight I had when starting the course.
	@Autowired
	private AccountService accountService;
	
	@Autowired
	private UserStorage users;
	
	@Autowired
	private AccountStorage accounts;
	
	@RequestMapping(value = {"/", "/registry"}, method = RequestMethod.GET)
	public String registry(Model model) {
		String username = this.getUsername();
		String output = OutputMessages.RGISTRY_INFORMATION;
		
		List<String> accountIds;
		if (hasRole("ROLE_BANK_EMPLOYEE")) {
			accountIds = this.accounts.getAllIds();
		} else {
			accountIds = this.accounts.getUserIds(username);	
		}
		
		List<DisplayData> displayData = null;
		if (accountIds != null) {
			displayData = this.accounts.getAccountDisplayData(accountIds);
		} else {
				output = OutputMessages.NO_ACCOUNTS_TO_DISPLAY;
		}
		
		model.addAttribute("displayData", displayData);
		model.addAttribute("output", output);
		
		return "registry";
	}
	
	@RequestMapping(value = "/operation")
	public String operation(Model model, @ModelAttribute(value = "SpringWeb") DatabaseOperation input) {
		String username = this.getUsername();
		List<String> accountIds = this.accounts.getUserIds(username);	
		model.addAttribute("accountIds", accountIds);
		String output = "Enter operation information:";
		
		if (accountIds == null) {
			output = OutputMessages.NO_ACCOUNTS_TO_OPERATE;
		} else {
			String amount = input.getOperationAmmount();
			String accountId = input.getSelectedAccountId();
			String operation = input.getSelectedOperation();
			String currency = input.getSelectedCurrency();
			
			Boolean amountIsValidNumber = amount != null && amount.matches("-?\\d+(\\.\\d+)?");
			Boolean amountIsEmptyString = amount != null && amount.equals("");
			if (operation != null && operation.equals("deposit") && amountIsValidNumber){
				output = this.accountService.deposit(accountId, amount, currency, username);
			} else if (operation != null && operation.equals("withdraw") && amountIsValidNumber){
				output = this.accountService.withdraw(accountId, amount, currency, username);
			} else if (amountIsEmptyString){
				output = OutputMessages.INVALID_OPERATION;
			}	
		}

		model.addAttribute("output", output);		
		if (output.toLowerCase().contains("success")) {
			return this.registry(model);
		}
		
		return "operation";
	}
	
	@RequestMapping(value = "/newAccount")
	public String newAccount(Model model, @ModelAttribute(value = "SpringWeb") NewAccountInput input) {
		String output = OutputMessages.ENTER_NEW_ACCOUNT_INFO;
				
		String[] possibleUsers = this.users.getUsernames();
		model.addAttribute("possibleUsers", possibleUsers);

		String selectedUser = input.getSelectedUser();
		List<String> accountIds = this.accounts.getUserIds(selectedUser);
		int accountNumber = accountIds == null ? 1 : accountIds.size() + 1;
		model.addAttribute("accountNumber", accountNumber);
		
		String initialBallance = input.getInitialBallance();
		String initialCurrency = input.getInitialCurrency();
		String accountKey = selectedUser + "-" + accountNumber;
		if (initialBallance == "") {
			output = OutputMessages.INVALID_INITIAL_BALLANCE;
		} else if (initialBallance != null) {
			String username = this.getUsername();
			output = this.accountService.deposit(accountKey, initialBallance, initialCurrency, username);
		}
		
		if (output.contains(OutputMessages.SUCCESSFUL_DEPOSIT_AND_REGISTER)) {
			DatabaseAccount accountData = new DatabaseAccount(
					accountKey,
					accountNumber,
					selectedUser,
					initialBallance,
					initialCurrency,
					this.getUsername());
			
			this.accounts.addAccount(accountData);
			
			return this.registry(model);
		}

		model.addAttribute("output", output);
		
		return "newAccount";
	}
	
	private String getUsername() {		
		SecurityContext context = SecurityContextHolder.getContext();
        if (context == null) {
            return null;        	
        }

        Authentication authentication = context.getAuthentication();
        if (authentication == null) {
            return null;
        }
        
        return authentication.getName();
	}
	
	private boolean hasRole(String role) {
        SecurityContext context = SecurityContextHolder.getContext();
        if (context == null) {
            return false;        	
        }

        Authentication authentication = context.getAuthentication();
        if (authentication == null) {
            return false;
        }

        for (GrantedAuthority auth : authentication.getAuthorities()) {
            if (role.equals(auth.getAuthority())) {
                return true;
            }
        }

        return false;
    }
}
