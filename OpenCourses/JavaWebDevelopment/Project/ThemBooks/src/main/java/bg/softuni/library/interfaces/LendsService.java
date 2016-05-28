package bg.softuni.library.interfaces;

import java.util.Set;

import bg.softuni.library.dto.lend.LendSearch;
import bg.softuni.library.entity.lend.Lend;

public interface LendsService {

	Set<Lend> getLends(LendSearch search);

	boolean addLend(Lend lend);

	boolean editLend(Lend lend);

}