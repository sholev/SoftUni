package bg.softuni.library.interfaces;

import java.util.Set;

import bg.softuni.library.entity.lend.Lend;

public interface LendStorage {

	Set<Lend> getLends();

	Set<Lend> getLends(Lend search);

	boolean addLend(Lend lend);

	boolean editLend(Long lendId, Lend updatedLend);

}