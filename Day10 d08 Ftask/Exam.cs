namespace Day10_d08_Ftask
{
    enum MultipleChoice
    {
        A,B, C, D
    }
    internal class Exam
    {
        public int NofQuestions { get; set; }
        public int ExamTime { get; set; }
        public List<QTrueFalse> ListQTF { get; set; }
        public List<QChooseOne> ListQCO { get; set; }
        public List<QChooseMul> ListQCM { get;set; }
        public Exam(int nofQuestions, int examTime, List<QTrueFalse> listQTF, List<QChooseOne> listQCO, List<QChooseMul> listQCM)
        {
            NofQuestions = nofQuestions;
            ExamTime = examTime;
            ListQTF = listQTF;
            ListQCO = listQCO;
            ListQCM = listQCM;
        }
        public virtual void TakeExam()
        {
            Console.WriteLine($"The No Of Questions are: {NofQuestions} \n The Exam Time is:{ExamTime}");
            int marks = 0;
            foreach (var item in ListQTF)
            {
                string egapto;

                do
                {
                    Console.WriteLine($"->{item.Header}");
                    Console.WriteLine($"{item.Body}");
                    egapto = Console.ReadLine();
                } while (egapto != "A" && egapto != "B");
                if (egapto.ToLower() == item.AnswerTF.Answers.ToLower())
                {
                    marks += item.Marks;
                }

            }
            foreach (var item in ListQCO)
            {
                string egapto;

                do
                {
                    Console.WriteLine($"->{item.Header}");
                    Console.WriteLine($"{item.Body}");
                    egapto = Console.ReadLine();
                } while (!Enum.IsDefined(typeof(MultipleChoice), egapto));
                //egapto != "a" && egapto != "b" && egapto != "c" && egapto != "d");
                if (egapto.ToLower() == item.AnswerChOne.Answers.ToLower())
                {
                    marks += item.Marks;
                }
            }

            bool CheckMC(string eg)
            {
                string[] arreg = eg.Split("-");
                for (int i = 0; i < arreg.Length; i++)
                {
                    for (int j = i + 1; j < arreg.Length; j++) { if (arreg[i] == arreg[j]) return true; }
                }
                if (!(arreg.Length > 1)) return true;       
                foreach (var i in arreg)
                {
                    if (!Enum.IsDefined(typeof(MultipleChoice), i)) return true;
                }
                return false;
            }

            foreach (var item in ListQCM)
            {
                string egapto;

                do
                {
                    Console.WriteLine($"->{item.Header} \n{item.Body}");
                    egapto = Console.ReadLine();

                } while (CheckMC(egapto));
                if (egapto.ToLower() == item.AnswerChmul.Answers.ToLower())
                {
                    marks += item.Marks;
                }
            }
            Console.WriteLine($"=====================================\n" +
                $"===||Your Result is {marks} out of 65||===" +
                $"\n=====================================");
        }
    }
    class FinalExam :Exam
    {
        public FinalExam(int nofQuestions, int examTime, List<QTrueFalse> listQTF,
            List<QChooseOne> listQCO, List<QChooseMul> listQCM) :base ( nofQuestions,  examTime,  listQTF,  listQCO,listQCM)
        {

        }
        public override void TakeExam()
        {
            base.TakeExam();

        }
    }
    class PracticalExam : Exam
    {
        //string ModelAnswer;
        public PracticalExam(int nofQuestions, int examTime, List<QTrueFalse> listQTF,
            List<QChooseOne> listQCO, List<QChooseMul> listQCM /*,string modelAnswer*/) : base(nofQuestions, examTime, listQTF, listQCO, listQCM)
        {
            //ModelAnswer= modelAnswer;
        }
        public override void TakeExam()
        {
             base.TakeExam();
            Console.WriteLine("\nThe Model Answer \n \nanswers are:-\n" +
                "-----------------------------\n"+
                "Q1) True Or false: \n1-True \n2-False \n3-False \n4-True \n5-False \n" +
                "-----------------------------\n"+
                "Q2) Choose the right answer: \n1- 2 \n2-Earth \n3-Writing \n4-orange \n5- 6 \n" +
                "-----------------------------\n"+
                "Q3) Choose more than one answer: \n1- apples-bananas-meat \n2-zoo-cage-forest \n3- Dog - Panda - Cat \n");
        }
    }
}
