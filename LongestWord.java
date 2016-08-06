public class LongestWord {

	public static void main(String[] args) {

		String answer = longestWord("hi another line");
		System.out.println(answer);

	}

	public static String longestWord(String input) {

		String[] words = input.split(" ");
		int largestWordIndex = 0;

		for (int i = 0; i < words.length; i++) {

			if (words[i].length() > words[largestWordIndex].length()) {

				largestWordIndex = i;
			}
		}

		return words[largestWordIndex];
	}

}
