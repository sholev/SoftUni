package bg.softuni.lebank.controllers;

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
import bg.softuni.lebank.dto.DisplayData;
import bg.softuni.lebank.entities.NewAccountInput;
import bg.softuni.lebank.entities.Operation;
import bg.softuni.lebank.interfaces.AccountsRepository;
import bg.softuni.lebank.interfaces.AccountsStorage;
import bg.softuni.lebank.interfaces.UsersStorage;

@Controller
public class BankingController {
	
	@Autowired
	private AccountsRepository accountsRepository;
	
	@Autowired
	private UsersStorage dbUsers;
	
	@Autowired
	private AccountsStorage dbAccounts;
	
	@RequestMapping(value = {"/", "/registry"}, method = RequestMethod.GET)
	public String registry(Model model) {
		String username = this.getUsername();
		String output = OutputMessages.RGISTRY_INFORMATION;
		
		String[] accountIds;
		if (hasRole("ROLE_BANK_EMPLOYEE")) {
			accountIds = this.dbAccounts.getAllIds();
		} else {
			accountIds = this.dbAccounts.getUserIds(username);	
		}
		
		DisplayData[] displayData = null;
		if (accountIds != null) {
			displayData = this.dbAccounts.getAccountDisplayData(accountIds);
		} else {
				output = OutputMessages.NO_ACCOUNTS_TO_DISPLAY;
		}
		
		model.addAttribute("displayData", displayData);
		model.addAttribute("output", output);
		
		return "registry";
	}
	
	@RequestMapping(value = "/operation")
	public String operation(Model model, @ModelAttribute(value = "SpringWeb") Operation input) {
		String username = this.getUsername();
		String[] accountIds = this.dbAccounts.getUserIds(username);	
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
				output = this.accountsRepository.deposit(accountId, amount, currency, username);
			} else if (operation != null && operation.equals("withdraw") && amountIsValidNumber){
				output = this.accountsRepository.withdraw(accountId, amount, currency, username);
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
				
		String[] possibleUsers = this.dbUsers.getUsernames();
		model.addAttribute("possibleUsers", possibleUsers);

		String selectedUser = input.getSelectedUser();
		String[] accountIds = this.dbAccounts.getUserIds(selectedUser);
		int accountNumber = accountIds == null ? 1 : accountIds.length + 1;
		model.addAttribute("accountNumber", accountNumber);
		
		String initialBallance = input.getInitialBallance();
		String initialCurrency = input.getInitialCurrency();
		String accountKey = selectedUser + "-" + accountNumber;
		if (initialBallance == "") {
			output = OutputMessages.INVALID_INITIAL_BALLANCE;
		} else if (initialBallance != null) {
			String username = this.getUsername();
			output = this.accountsRepository.deposit(accountKey, initialBallance, initialCurrency, username);
		}
		
		if (output.contains(OutputMessages.SUCCESSFUL_DEPOSIT_AND_REGISTER)) {
			this.dbAccounts.addAccount(accountKey, accountNumber, selectedUser, initialBallance, initialCurrency, this.getUsername());
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
