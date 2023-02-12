fn main() {
    let mut list = Vec::new();
    for i in 1..=100 {
        let mut s = CollatzSequence {
            sequence: Vec::new(),
            start: i
        };

        s.run_sequence(i);

        list.push(s);
    }

    for s in list {
        if s.sequence.len() > 1 {
            println!("\n{:?}", s.sequence);
        }
    }
}

struct CollatzSequence {
    start: u64,
    sequence: Vec<u64>
}

trait Collatz {
    fn run(&self, start: u64) -> u64;
    fn run_sequence(&mut self, start: u64) -> Vec<u64>;
}

impl Collatz for CollatzSequence {
    fn run(&self, start: u64) -> u64 {
        if start % 2 == 0 {
            start / 2
        } else {
            start * 3 + 1
        }
    }

    fn run_sequence(&mut self, start: u64) -> Vec<u64> {
        let mut current = start;
        self.sequence.push(current);

        if current == 1 {
            return self.sequence.clone()
        }

        while current > 1 {
            current = self.run(current);
            self.sequence.push(current);
        }

        self.sequence.clone()
    }
}